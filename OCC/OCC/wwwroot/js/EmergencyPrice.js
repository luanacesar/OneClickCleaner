//Function to calculate the price based on the hour.

function emergencyPrice() {
	var choiceHour;
	var totalPrice = 0;
	const PRICE_EMERGENCY_SERV_PER_HOUR = 70.0;

	if (document.getElementById("option1").checked) {
		choiceHour = 1;
	} else if (document.getElementById("option2").checked) {
		choiceHour = 2;
	} else if (document.getElementById("option3").checked) {
		choiceHour = 3;
	} else if (document.getElementById("option4").checked) {
		choiceHour = 4;
	} else if (document.getElementById("option5").checked) {
		choiceHour = 5;
	} else if (document.getElementById("option6").checked) {
		choiceHour = 6;
	}

	totalPrice = choiceHour * PRICE_EMERGENCY_SERV_PER_HOUR;

	document.getElementById("result").innerHTML = "Price: $ " + totalPrice.toFixed(2);

}



