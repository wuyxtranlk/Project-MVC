import apiService from '/js/share/apiService.js';
const input = document.getElementById('find');
const datalist = document.getElementById('autocomplete-list');
let getTimer;
input.addEventListener('input', () => {

    clearTimeout(getTimer);
    const term = input.value.trim();
    if (!term) {
        datalist.innerHTML = '';
        return;
    }
    getTimer = setTimeout(async () => {
        try {
            const urlTemplate = input.getAttribute('data-url');
            const url = urlTemplate.replace('__term__', encodeURIComponent(term));
            const suggestions = await apiService.get(url);
            datalist.innerHTML = suggestions
                .map(item => `<option value="${item}"></option>`)
                .join('');
        } catch (error) {
            console.error('Error fetching suggestions:', error);
        }
    }, 300);
});
