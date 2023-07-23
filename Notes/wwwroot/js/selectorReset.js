class SelectorReset {
    static attachResetHandler(buttonId, fieldsToReset) {
        const resetButton = document.getElementById(buttonId);
        
        if (!resetButton) {
            return;
        }
        
        resetButton.addEventListener("click", function () {
           fieldsToReset.forEach((field) => {
               const input = document.querySelector(field.selector);
               
               if (input) {
                   input.value = "";
               }
           });
           
           const searchForm = resetButton.closest("form");
           
           if (searchForm) {
               searchForm.submit();
           }
           
        });
    }
}