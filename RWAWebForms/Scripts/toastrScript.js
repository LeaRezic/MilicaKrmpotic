function showToastr(type, message) {
    switch (type) {
        case 'info':
            toastr.info(message);
            break;
        case 'warning':
            toastr.warning(message);
            break;
        case 'success':
            toastr.success(message);
            break;
        default:
            break;
    }
}