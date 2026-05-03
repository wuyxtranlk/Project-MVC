import apiService from '/js/shared/apiService.js';
document.getElementById("btnGetNameQuery").addEventListener('click',
	async () => {
		try {
			const urlTemplate = document.getElementById("btnGetNameQuery").getAttribute("data-url-template");
			//const urlTemplate = document.getElementById("btnGetNameQuery").dataset.urlTemplate;
			const name = document.getElementById("txtName").value
            const url = urlTemplate.replace("__name__", encodeURIComponent(name));
			const result = await apiService.get(url);
			document.getElementById('resultName').textContent = result.fullname;
		} catch (error) {
			console.error('Error fetching message:', error);
			document.getElementById('resultName').textContent = 'Error fetching message.';
		}
	});