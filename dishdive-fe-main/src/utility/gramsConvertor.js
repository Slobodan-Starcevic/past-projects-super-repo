export function gramsConvertor(grams) {

   if(1 < grams < 1000){
      return `${grams}g`;
    }
    else if(grams >= 1000){
        const kg = (grams / 1000).toFixed(2);
        return `${kg}kg`;
      }
  };