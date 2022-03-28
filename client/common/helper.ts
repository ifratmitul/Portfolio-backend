export const dateFormatter = (date: Date): string => {
    const months = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];
  
    let month: string = months[date.getMonth()];
    let year: string = date.getFullYear().toString();
    let res: string = month + " " + year;
    return res;
  };