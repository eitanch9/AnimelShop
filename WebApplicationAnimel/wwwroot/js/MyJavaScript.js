$(document).ready(function () {
    $('#Categories').change(function () {
        let selectedValue = $('#Categories').val();
        window.location.href="/Animal/Animal/"+selectedValue
    })
})