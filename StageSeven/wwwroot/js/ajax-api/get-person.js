import apiService from '/js/shared/apiService.js';
document.getElementById("btnSendPerson").addEventListener('click',
	async () => {
			const name = document.getElementById("txtFullname").value.trim();
			const age = document.getElementById("txtAge").value.trim();

		if (!name) {
			document.getElementById("resultPerson").innerHTML = "<b style='color:red'>Please enter a valid name.</b>";
			return;
		}

		if (!/^\d+$/.test(age)) {
			document.getElementById("resultPerson").innerHTML = "<b style='color:red'>Please enter a valid age must be a number.</b>";
			return;
		}
		var ageValue = parseInt(age);
		if (ageValue < 0 || ageValue > 120) {
			document.getElementById("resultPerson").innerHTML = "<b style='color:red'>Please enter a valid age between 0 and 120.</b>";
			return;
		}
		try {
			const url = document.getElementById("btnSendPerson").getAttribute("data-url");
            const person = { Name: name, Age: ageValue };
			const result = await apiService.post(url, person);
			document.getElementById('resultPerson').textContent = `Fullname: ${result.fullname}, Age: ${result.age}`;
		} catch (error) {
			console.error('Error fetching message:', error);
			document.getElementById('resultPerson').textContent = 'Error fetching message.';
		}
	});