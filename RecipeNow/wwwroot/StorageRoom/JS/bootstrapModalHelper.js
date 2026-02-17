window.bootstrapModalHide = (modalEl) => {
    const m = bootstrap.Modal.getInstance(modalEl) || new bootstrap.Modal(modalEl);
    m.hide();
};

window.bootstrapModalShow = (el) => {
    if (!el) return;
    const modal = new bootstrap.Modal(el);
    modal.show();
};
