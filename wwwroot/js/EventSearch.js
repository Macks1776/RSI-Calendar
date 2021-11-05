function toggleName() {
    document.getElementById("eventSearchName").disabled = !(document.getElementById("nameCheckbox").checked);
}

function toggleDate() {
    document.getElementById("eventSearchStartDate").disabled = !(document.getElementById("dateCheckbox").checked);
    document.getElementById("eventSearchEndDate").disabled = !(document.getElementById("dateCheckbox").checked);
}