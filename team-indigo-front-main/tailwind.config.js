/** @type {import('tailwindcss').Config} */
module.exports = {
  purge: ['./src/**/*.{js,jsx,ts,tsx}', './public/index.html'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      colors:{
        "main-blue" : "#5b73a0",
        "blue-dark" : "#344146",
        "main-green" : "#2bab70",
      },
      screens: {
        'mid': '1180px',
        'zero' : '0px'
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [require("@tailwindcss/forms")],
}