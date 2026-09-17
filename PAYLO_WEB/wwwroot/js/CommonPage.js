let currentPage = 1;
let pageSize = 10;
let sortColumn = "";
let sortDirection = "asc";

function initCommonTable(options = {}) {
    currentPage = 1;
    pageSize = options.pageSize || 10;
    sortColumn = options.defaultSortColumn || "";
    sortDirection = "asc";
    $("#pageSize").val(pageSize);

    $("#commonSearch").off("keyup.commonTable").on("keyup.commonTable", function () {
        currentPage = 1;
        if (typeof renderTable === "function") renderTable();
    });

    $("#statusFilter").off("change.commonTable").on("change.commonTable", function () {
        currentPage = 1;
        if (typeof renderTable === "function") renderTable();
    });

    $("#pageSize").off("change.commonTable").on("change.commonTable", function () {
        pageSize = parseInt($(this).val(), 10) || 10;
        currentPage = 1;
        if (typeof renderTable === "function") renderTable();
    });

    $("#btnClearSearch").off("click.commonTable").on("click.commonTable", function () {
        $("#commonSearch").val("");
        $("#statusFilter").val("");
        currentPage = 1;
        if (typeof renderTable === "function") renderTable();
    });

    $(document).off("click.commonTable", "th.sortable").on("click.commonTable", "th.sortable", function () {
        const column = $(this).data("column");
        if (!column) return;
        if (sortColumn === column) {
            sortDirection = sortDirection === "asc" ? "desc" : "asc";
        } else {
            sortColumn = column;
            sortDirection = "asc";
        }
        currentPage = 1;
        if (typeof renderTable === "function") renderTable();
    });
}

function getCommonFilteredData(data) {
    let result = Array.isArray(data) ? [...data] : [];
    const search = String($("#commonSearch").val() || "").trim().toLowerCase();
    if (search !== "") {
        result = result.filter(item =>
            Object.keys(item).some(key => {
                const value = item[key];
                if (value == null) return false;
                return String(value).toLowerCase().includes(search);
            })
        );
    }
    const status = String($("#statusFilter").val() || "").trim().toLowerCase();
    if (status !== "") {
        result = result.filter(item => String(item.status || "").toLowerCase() === status);
    }
    return result;
}

function sortCommonData(data) {
    if (!sortColumn) return data;
    return data.sort((a, b) => {
        let valueA = a[sortColumn], valueB = b[sortColumn];
        if (valueA == null) valueA = "";
        if (valueB == null) valueB = "";
        const numberA = Number(valueA), numberB = Number(valueB);
        const bothNumeric = valueA !== "" && valueB !== "" && !isNaN(numberA) && !isNaN(numberB);
        if (bothNumeric) { valueA = numberA; valueB = numberB; }
        else { valueA = String(valueA).toLowerCase(); valueB = String(valueB).toLowerCase(); }
        if (valueA < valueB) return sortDirection === "asc" ? -1 : 1;
        if (valueA > valueB) return sortDirection === "asc" ? 1 : -1;
        return 0;
    });
}

function getCommonTableData(data) {
    let result = getCommonFilteredData(data);
    result = sortCommonData(result);
    return result;
}

function getCommonPageData(data) {
    const totalRecords = Array.isArray(data) ? data.length : 0;
    const totalPages = Math.ceil(totalRecords / pageSize);
    if (totalPages > 0 && currentPage > totalPages) currentPage = totalPages;
    if (totalPages === 0) currentPage = 1;
    const startIndex = (currentPage - 1) * pageSize;
    const endIndex = Math.min(startIndex + pageSize, totalRecords);
    const pageData = data.slice(startIndex, endIndex);
    return { pageData, totalRecords, totalPages, startIndex, endIndex };
}

function renderPagination(totalPages) {
    let html = "";
    if (totalPages <= 1) { $("#pagination").html(""); return; }
    html += `<button type="button" class="page-btn" ${currentPage === 1 ? "disabled" : ""} onclick="changePage(${currentPage - 1})"><i class="bi bi-chevron-left"></i> Previous</button>`;
    for (let i = 1; i <= totalPages; i++) {
        html += `<button type="button" class="page-btn ${i === currentPage ? "active" : ""}" onclick="changePage(${i})">${i}</button>`;
    }
    html += `<button type="button" class="page-btn" ${currentPage === totalPages ? "disabled" : ""} onclick="changePage(${currentPage + 1})">Next <i class="bi bi-chevron-right"></i></button>`;
    $("#pagination").html(html);
}

window.changePage = function (page) {
    const filteredData = typeof allData !== "undefined" && Array.isArray(allData) ? getCommonTableData(allData) : [];
    const totalPages = Math.ceil(filteredData.length / pageSize);
    if (page < 1 || page > totalPages) return;
    currentPage = page;
    if (typeof renderTable === "function") renderTable();
};

function updateRecordInfo(startIndex, endIndex, totalRecords) {
    if (totalRecords === 0) {
        $("#recordInfo").text("Showing 0 to 0 of 0 entries");
        return;
    }
    $("#recordInfo").text(`Showing ${startIndex + 1} to ${endIndex} of ${totalRecords} entries`);
}

function exportCommonExcel(data, columns, fileName) {
    if (!Array.isArray(data) || data.length === 0) { alert("No records available to export."); return; }
    let csv = columns.map(column => `"${csvEscape(column.header)}"`).join(",") + "\n";
    data.forEach((item, index) => {
        const row = columns.map(column => {
            let value;
            if (column.field === "sno") value = index + 1;
            else if (typeof column.format === "function") value = column.format(item, index);
            else value = item[column.field];
            if (value == null) value = "";
            return `"${csvEscape(value)}"`;
        });
        csv += row.join(",") + "\n";
    });
    const blob = new Blob([csv], { type: "text/csv;charset=utf-8;" });
    const url = URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.href = url;
    link.download = fileName || "Export.csv";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    URL.revokeObjectURL(url);
}

function csvEscape(value) {
    return String(value ?? "").replace(/"/g, '""');
}
