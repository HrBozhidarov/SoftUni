function addItem() {
    let newItemText = $('#newItemText');
    let newItemValue = $('#newItemValue');
    let menu = $('#menu');

    let option = $(`<option value="${newItemValue.val()}">${newItemText.val()}</option>`);

    menu.append(option);
    newItemValue.val('');
    newItemText.val('');
}