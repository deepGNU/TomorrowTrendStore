import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7046/api",
    headers: {
        "Content-Type": "application/json",
    },
});

api.defaults.headers.common['Content-Type'] = 'application/json';

export const setAuthTokenFromSessionStorage = () => {
    const token = sessionStorage.getItem("e-store-jwt");
    if (token) {
        api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    } else {
        delete api.defaults.headers.common["Authorization"];
    }
    return token !== null;
}

// Sets the JWT on import of this file.
setAuthTokenFromSessionStorage();

export default api;