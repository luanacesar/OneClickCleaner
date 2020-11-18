
window.onload = function () {
    const elem = document.getElementById('service-day');
    const minDate = new Date();

    minDate.setDate(minDate.getDate() + 2);
    const maxDate = new Date();
    maxDate.setDate(maxDate.getDate() + 100);
    elem.min = minDate.toISOString().slice(0, 10);
    if (elem.value < elem.min) {
        elem.value = elem.min;
    }
    elem.max = maxDate.toISOString().slice(0,10);
}

