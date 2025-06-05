const sectors = [
    { label: '5%', color: '#FFD700' },
    { label: '10%', color: '#ADFF2F' },
    { label: '20%', color: '#00BFFF' },
    { label: 'شانس دوباره', color: '#FF6347' },
    { label: '30%', color: '#8A2BE2' },
    { label: 'شانس دوباره', color: '#FF6347' },
];
const wheelCanvas = document.getElementById('wheelCanvas');
const ctx = wheelCanvas.getContext('2d');
const spinBtn = document.getElementById('spinBtn');
const resultDiv = document.getElementById('result');
const radius = 150;
const arc = (2 * Math.PI) / sectors.length;
function drawWheel() {
    sectors.forEach((sector, i) => {
        const angle = i * arc;
        ctx.beginPath();
        ctx.fillStyle = sector.color;
        ctx.moveTo(radius, radius);
        ctx.arc(radius, radius, radius, angle, angle + arc);
        ctx.lineTo(radius, radius);
        ctx.fill();
        ctx.save();
        ctx.translate(radius, radius);
        ctx.rotate(angle + arc / 2);
        ctx.textAlign = 'right';
        ctx.fillStyle = '#000';
        ctx.font = 'bold 14px sans-serif';
        ctx.fillText(sector.label, radius - 10, 5);
        ctx.restore();
    });
}
drawWheel();
let spinning = false;
spinBtn.addEventListener('click', () => {
    if (spinning) return;
    spinning = true;
    resultDiv.textContent = '';
    const duration = 5000;
    const spins = 6;
    const randomSector = Math.floor(Math.random() * sectors.length);
    const endAngle = (2 * Math.PI * spins) + (randomSector * arc) + (arc / 2);
    const start = performance.now();
    function animate(time) {
        const elapsed = time - start;
        const progress = Math.min(elapsed / duration, 1);
        const angle = endAngle * easeOutCubic(progress);
        ctx.clearRect(0, 0, 300, 300);
        ctx.save();
        ctx.translate(radius, radius);
        ctx.rotate(angle);
        ctx.translate(-radius, -radius);
        drawWheel();
        ctx.restore();
        if (progress < 1) {
            requestAnimationFrame(animate);
        }
        else {
            const result = sectors[randomSector].label;
            sendToServer(result);
            spinning = false;
        }
    }
    requestAnimationFrame(animate);
});
function easeOutCubic(t) {
    return (--t) * t * t + 1;
}
async function sendToServer(resultText) {
    try {

        const response = await fetch('api/spin/spin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ resultText })
        });
        const data = await response.json();
        resultDiv.innerHTML = data.code ? `${data.message}` : `${data.message}`;
    }
    catch (error) {
        resultDiv.innerHTML = "خطا در ازتباط با سرور";
        console.error(error);
    }
}