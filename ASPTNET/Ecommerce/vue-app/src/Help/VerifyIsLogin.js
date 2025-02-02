export const VerifyIsLogin = () => {
    return localStorage.getItem('user') ? true : false;
}

