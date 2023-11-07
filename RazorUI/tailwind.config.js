/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./**/*.{razor,html,cshtml,css}",
  ],
  theme: {
    fontFamily: {
        'body': ['Nunito', 'system-ui', 'sans-serif']
    },
    container: {
        center: true,
        padding: {
            DEFAULT: '1rem',
            sm: '2rem',
            lg: '4rem',
            xl: '5rem',
            '2xl': '6rem',
        },
    }
  },
  plugins: [
      require('@tailwindcss/forms')
  ],
}