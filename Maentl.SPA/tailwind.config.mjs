export default {
  darkMode: ["class"],
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}"
  ],
  theme: {
    container: {
      center: true,
      padding: '2rem',
      screens: {
        '2xl': '1400px'
      }
    },
    extend: {
      colors: {
        primary: {
          DEFAULT: '#1D4ED8',
          foreground: '#FFFFFF'
        },
        secondary: {
          DEFAULT: '#E5E7EB',
          foreground: '#1F2937'
        },
        destructive: {
          DEFAULT: '#DC2626',
          foreground: '#FFFFFF'
        },
        muted: {
          DEFAULT: '#F3F4F6',
          foreground: '#6B7280'
        },
        accent: {
          DEFAULT: '#9CA3AF',
          foreground: '#1F2937'
        },
        popover: {
          DEFAULT: '#FFFFFF',
          foreground: '#1F2937'
        },
        card: {
          DEFAULT: '#FFFFFF',
          foreground: '#1F2937'
        }
      }
    }
  },
  plugins: [
    require("tailwindcss-animate")
  ]
}
