
//const editmessageurl =Url.Action("EditMessageAjax","Chat");
function showEditBoxx(id) {
    document.getElementById("edit-box-" + id).style.display = "block";
}
//function submitEdit(messageId) {
//    console.log("Posting To:", editmessageurl);
//    console.log("subbmit called for", messageId);
//    const newText = document.getElementById("edit-input-" + messageId).value;
//    console.log("new text=", newText);
//    fetch('/Chat/EditMessageAjax', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',

//        },
//        body: JSON.stringify({
//            messageId: messageId,
//            newText: newText
//        })
//    })
//        .then(response => {
//            console.log("responce status:", response.status);
//            if (!response.ok) {
//                throw new Error("Status Code:" + response.status);
//            }
//            return response.json();
//        })

//    .then(response => response.json())
//        .then(data => {
//            console.log("data:", data);
//            if (data.success) {
//                document.getElementById("message-text-" + messageId).innerText = newText;
//                document.getElementById("edit-box-" + messageId).style.display = "none";
//            }
//            else {
//                alert("Dont Can Edit Message");
//            }
//        })
//        .catch(() => {
//            console.error("fetch error", error);
//            alert("Error To Send Data");
//});



//    }
function toggleEdit(id, oldMessage) {
    const form = document.getElementById('edit-form-' + id);
    const input = document.getElementById('edit-input-' + id);
    if (form.style.display === 'none'||form.style.display==='') {
        form.style.display = 'block';
        input.value = oldMessage;
    }
    else {
        form.style.display = 'none';
    }
}
    