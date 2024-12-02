function getTimeAgo(creationDate) {
    const currentDate = new Date();
    const created = new Date(creationDate);

    const timeDifference = currentDate - created;

    const secondsAgo = Math.floor(timeDifference / 1000);

    if(secondsAgo < 60){
      return `${secondsAgo} second${secondsAgo !== 1 ? "s" : ""}`;
    }
    else if(secondsAgo < 360){
      const minutesAgo = Math.floor(secondsAgo/60);
      return `${minutesAgo} minute${minutesAgo !== 1 ? "s" : ""}`;
    }
    else if(secondsAgo < 8640){
      const hoursAgo = Math.floor(secondsAgo/360);
      return `${hoursAgo} hour${hoursAgo !== 1 ? "s" : ""}`;
    }
    else if(secondsAgo < 259200){
      const daysAgo = Math.floor(secondsAgo/8640);
      return `${daysAgo} day${daysAgo !== 1 ? "s" : ""}`;
    }
    else if(secondsAgo < 3110400){
      const monthsAgo = Math.floor(secondsAgo/259200);
      return `${monthsAgo} month${monthsAgo !== 1 ? "s" : ""}`;
    }
    else if(secondsAgo > 3110400){
      const yearsAgo = Math.floor(secondsAgo/3110400);
      return `${yearsAgo} year${yearsAgo !== 1 ? "s" : ""}`;
    }
  };

export {getTimeAgo};