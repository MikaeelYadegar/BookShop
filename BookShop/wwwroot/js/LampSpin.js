const lamps = document.querySelectorAll('.lamp');
let isOn = false;


setInterval(() => {
    isOn = !isOn;
    lamps.forEach((lamp, index)=> {
        if ((index + (isOn ? 0 : 1)) % 2 === 0) {
            lamp.src = 'Lamp_ONN-removebg-preview.png';
        }
        else {
            lamp.src = 'Lamp_Off-removebg-preview.png';
        }

    });
    }, 1000);