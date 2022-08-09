const form = document.querySelector('form');
const completePaymentButton = document.querySelector('button#complete-payment');

form.addEventListener('submit', handleFormSubmission);

function handleFormSubmission(event) {
    event.preventDefault();
    if (form.checkValidity() === false) {
        // Handle invalid form data.
    } else {
        completePaymentButton.textContent = 'Making payment...';
        completePaymentButton.disabled = 'true';
        setTimeout(() => { alert('Made payment!'); }, 500);
    }
}