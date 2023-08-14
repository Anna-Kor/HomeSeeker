import { defineStore } from 'pinia';

enum ThemeEnum {
    light = 'light-theme',
    dark = 'dark-theme'
}

interface IThemeState {
    theme: string
}

export const useThemeStore = defineStore({
    id: 'theme',
    state: (): IThemeState => {
        const activeTheme = localStorage.getItem('theme');
        const theme = activeTheme !== null ? activeTheme : ThemeEnum.light;
        document.documentElement.className = theme;
        return {
            theme: theme,
        }
    },
    actions: {
        changeTheme() {
            const activeTheme = localStorage.getItem("theme");
            if (activeTheme === ThemeEnum.light) {
                this.theme = ThemeEnum.dark;
            } else {
                this.theme = ThemeEnum.light;
            }
            localStorage.setItem("theme", this.theme);
            document.documentElement.className = this.theme;
        }
    }
});