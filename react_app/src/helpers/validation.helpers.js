export default function isValid(person) {
    let errorMessage = '';
    let isValid = true;
console.log(person);
    if (person.name.trim() === '') {
        errorMessage = 'Name is required';
        isValid = false;
    }

    else if (!isValidDate(person.dateOfBirth)) {


        errorMessage = 'Please enter a valid date (e.g., MM/DD/YYYY)';
        isValid = false;
    }
    else if (typeof(person.isMarried)=='string' && (person.isMarried.toLowerCase() !== 'true' && person.isMarried.toLowerCase() !== 'false')) {

        errorMessage = 'Please enter either "true" or "false"';
        isValid = false;
    }

    else if (!/^\d{10}$/.test(person.phoneNumber)) {
        errorMessage = 'Please enter a valid 10-digit phone number';
        isValid = false;
    }
    else if (isNaN(person.salary) || person.salary <= 0) {

        errorMessage = 'Please enter a valid positive number for salary';
        isValid = false;
    }

    return { isValid, errorMessage };
}
function isValidDate(dateString) {
    const date = new Date(dateString);
    return !isNaN(date.getTime()) && date.toISOString().slice(0, 10) === dateString;
}
