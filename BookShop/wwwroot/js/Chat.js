async function sendMessage(sender, message) {
    const response = await fetch('api/chat/send', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ sender, message })
    });
    if (response.ok) {
        console.log('Text Send');
        loadMessage();
    }
}
async function loadMessage() {
    const response = await fetch('api/chat/messages')
    const messages = await response.json();
    const messageList = document.getElementById('messagesList');
    messageList.innerHTML = '';
    messages.forEach(msg => {
        const li = document.createElement('li');
        li.textContent = '${msg.user}:${msg.message}';
        messageList.appendChild(li);
    });
}
loadMessage();