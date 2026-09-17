let deleteCustomerId = 0;

$(document).ready(function () {
    // Initialize common table (search, sort, pagination handled in common-table.js)
    initCommonTable({ pageSize: 10, defaultSortColumn: "customerName" });

    // Load report on page load
    loadCustomers();

    // Form events
    $("#btnAddCustomer").on("click", openAddCustomer);
    $("#btnCloseForm, #btnCancel").on("click", closeCustomerForm);
    $("#customerForm").on("submit", function (e) {
        e.preventDefault();
        saveCustomer();
    });

    // Delete modal events
    $("#btnDeleteCancel").on("click", closeDeleteModal);
    $("#btnDeleteConfirm").on("click", deleteCustomer);

    // Image preview
    $("#aadhaarImage").on("change", function () { previewImage(this, "#aadhaarPreview"); });
    $("#panImage").on("change", function () { previewImage(this, "#panPreview"); });
});

// 🔹 Refresh ViewComponent (Get Report)
function loadCustomers() {
    $.ajax({
        url: "/Admin/GetCustomers",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({}),
        success: function (html) {
            // Replace the ViewComponent container with fresh HTML
            $("#Report").html(html);
        },
        error: function () {
            showToast("Failed to load customers", true);
        }
    });
}

// 🔹 Insert / Update
function saveCustomer() {
    if (!validateCustomer()) return;
    debugger
    const form = document.getElementById("customerForm");
    if (!form) {
        showToast("Customer form not found.", true);
        return;
    }

    const formData = new FormData(form);
    const id = parseInt($("#customerId").val(), 10) || 0;
    //const url = id > 0 ? "/Admin/Customer/Update" : "/Admin/Customer/Create";

    $("#btnSave").prop("disabled", true);

    $.ajax({
        url: "/Admin/InsertAndUpdateCustomerDetails",
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response && response.success) {
                showToast(response.message || (id > 0 ? "Customer updated successfully." : "Customer created successfully."));
                closeCustomerForm();
                loadCustomers(); // refresh ViewComponent
            } else {
                showToast(response && response.message ? response.message : "Unable to save customer", true);
            }
        },
        error: function () {
            showToast("Something went wrong while saving customer.", true);
        },
        complete: function () {
            $("#btnSave").prop("disabled", false);
        }
    });
}

// 🔹 Delete
function confirmDelete(id) {
    deleteCustomerId = id;
    $("#deleteModal").fadeIn(200);
}

function closeDeleteModal() {
    $("#deleteModal").fadeOut(200);
    deleteCustomerId = 0;
}

function deleteCustomer() {
    if (deleteCustomerId <= 0) {
        closeDeleteModal();
        return;
    }

    $.ajax({
        url: "/Admin/Customer/Delete",
        type: "POST",
        data: { id: deleteCustomerId },
        success: function (response) {
            closeDeleteModal();
            if (response && response.success) {
                showToast(response.message || "Customer deleted successfully.");
                loadCustomers(); // refresh ViewComponent
            } else {
                showToast(response && response.message ? response.message : "Delete failed", true);
            }
        },
        error: function () {
            closeDeleteModal();
            showToast("Unable to delete customer", true);
        }
    });
}

// 🔹 Form helpers
function openAddCustomer() {
    resetForm();
    $("#btnSaveText").text("Save Customer");
    $("#customerFormCard").slideDown(200);
    scrollToCustomerForm();
}

function closeCustomerForm() {
    resetForm();
    $("#customerFormCard").slideUp(200);
}

function resetForm() {
    const form = $("#customerForm")[0];
    if (form) form.reset();
    $("#customerId").val(0);
    $("#status").val("Active");
    $("#aadhaarPreview, #panPreview").empty();
    $("#aadhaarImage, #panImage").val("");
    $("#btnSaveText").text("Save Customer");
    clearCustomerErrors();
}

function clearCustomerErrors() {
    $(".field-error").text("");
    $(".form-control").removeClass("input-error is-invalid");
}

function scrollToCustomerForm() {
    const formCard = $("#customerFormCard");
    if (!formCard.length) return;
    const position = formCard.offset();
    if (!position) return;
    $("html, body").animate({ scrollTop: position.top - 20 }, 400);
}

// 🔹 Validation
function validateCustomer() {
    clearCustomerErrors();
    let valid = true;

    const name = String($("#customerName").val() || "").trim();
    if (!name) { $("#customerNameError").text("Customer name is required"); valid = false; }

    const mobile = String($("#mobileNumber").val() || "").trim();
    if (!/^[0-9]{10}$/.test(mobile)) { $("#mobileNumberError").text("Enter valid 10 digit mobile number"); valid = false; }

    const email = String($("#email").val() || "").trim();
    if (email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) { $("#emailError").text("Enter valid email address"); valid = false; }

    const aadhaar = String($("#aadhaarNumber").val() || "").trim();
    if (aadhaar && !/^[0-9]{12}$/.test(aadhaar)) { $("#aadhaarNumberError").text("Aadhaar must contain 12 digits"); valid = false; }

    const pan = String($("#panNumber").val() || "").trim().toUpperCase();
    $("#panNumber").val(pan);
    if (pan && !/^[A-Z]{5}[0-9]{4}[A-Z]{1}$/.test(pan)) { $("#panNumberError").text("Enter valid PAN number"); valid = false; }

    const status = $("#status").val();
    if (!status) { $("#statusError").text("Please select status"); valid = false; }

    return valid;
}

// 🔹 Utilities
function previewImage(input, previewSelector) {
    const file = input.files && input.files[0];
    if (!file) return;
    const allowedTypes = ["image/jpeg", "image/jpg", "image/png"];
    if (!allowedTypes.includes(file.type)) {
        showToast("Only JPG, JPEG and PNG files are allowed.", true);
        $(input).val("");
        return;
    }
    if (file.size > 5 * 1024 * 1024) {
        showToast("Image size should not exceed 5 MB.", true);
        $(input).val("");
        return;
    }
    const reader = new FileReader();
    reader.onload = function (e) {
        $(previewSelector).html(`<img src="${e.target.result}" class="document-preview-image" alt="Preview">`);
    };
    reader.readAsDataURL(file);
}

function maskAadhaar(value) {
    const cleanValue = String(value || "").replace(/\D/g, "");
    if (cleanValue.length !== 12) return value || "-";
    return "XXXX-XXXX-" + cleanValue.substring(8);
}

function showToast(message, isError = false) {
    $("#toastMessage").text(message);
    $("#toast").toggleClass("error", isError).fadeIn(200);
    setTimeout(function () { $("#toast").fadeOut(200); }, 3000);
}

function escapeHtml(value) {
    return String(value ?? "")
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}
