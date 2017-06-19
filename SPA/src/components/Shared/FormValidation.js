export const required = value => value ? undefined : 'Required';
export const wholeNumber = value => value && !/^-?\d+$/g.test(value) ? 'Must be a whole number' : undefined
export const minValue = min => value =>
  value && value <= min ? `Must be greater than ${min}` : undefined
export const decimal = value => value && isNaN(Number(value)) ? 'Must be a number' : undefined
export const dateValidator = value => value && !/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/.test(value)  ? 'Must be in format dd/mm/yyyy, dd-mm-yyyy, or dd.mm.yyyy' : undefined