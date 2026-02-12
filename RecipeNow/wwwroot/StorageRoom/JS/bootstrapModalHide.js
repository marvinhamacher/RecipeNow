window.bootstrapModalHide = (modalEl) => {
    const m = bootstrap.Modal.getInstance(modalEl) || new bootstrap.Modal(modalEl);
    m.hide();
};