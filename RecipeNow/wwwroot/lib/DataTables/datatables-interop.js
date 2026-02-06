window.recipeNow = window.recipeNow || {};

recipeNow.initIngredientsTable = function (selector) {
    // vorhandene Instanz wegwerfen (wichtig bei Re-Render / Reload)
    if (recipeNow._ingredientsDt) {
        recipeNow._ingredientsDt.destroy();
        recipeNow._ingredientsDt = null;
    }

    recipeNow._ingredientsDt = new DataTable(selector, {
        autoWidth: false,          // SEHR wichtig
        responsive: false,         // sonst überschreibt DT die Breiten
        columnDefs: [
            { targets: 0, width: "40%" }, // Name
            { targets: 1, width: "20%" }, // Preis
            { targets: 2, width: "20%" }, // Measurement
            {
                targets: 3,
                width: "20%",
                orderable: false,
                searchable: false
            }
        ],
        language: {
            emptyTable: "Keine Zutaten vorhanden",
            search: "Suche:",
            lengthMenu: "_MENU_ Einträge anzeigen",
            info: "_START_–_END_ von _TOTAL_"
        }
    });
};

recipeNow.destroyIngredientsTable = function () {
    if (recipeNow._ingredientsDt) {
        recipeNow._ingredientsDt.destroy();
        recipeNow._ingredientsDt = null;
    }
};

// Bootstrap Modal programmatic hide
recipeNow.hideModal = function (modalSelector) {
    const el = document.querySelector(modalSelector);
    if (!el) return;

    const instance = bootstrap.Modal.getInstance(el) || new bootstrap.Modal(el);
    instance.hide();
};

