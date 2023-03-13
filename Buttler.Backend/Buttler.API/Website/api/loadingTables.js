<script>
    // fetch data from RESTful API
    fetch('http://localhost:5157/api/Reports')
    .then(response => response.json())
    .then(data => {
    // get table element
    const table = document.querySelector('table');

    // loop through data and add rows to table
    data.forEach(report => {
    const row = table.insertRow(-1);
    row.insertCell(0).textContent = report.reportId;
    row.insertCell(1).textContent = report.userName;
    row.insertCell(2).textContent = report.timeStamp;
    row.insertCell(3).textContent = report.numberOfWaste;
    row.insertCell(4).textContent = report.wasteType;
    row.insertCell(5).textContent = report.latitude;
    row.insertCell(6).textContent = report.longitude;
});
})
    .catch(error => console.error(error));
</script>
