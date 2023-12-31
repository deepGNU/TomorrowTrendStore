import api from "../e-store-api";
import { addUser } from "../../features/users/users-slice";

export const registerAPI = async (dispatch, user) => {
    try {
        const response = await api.post('/register', user);
        dispatch(addUser(response.data));
    } catch (error) {
        console.error(error.message);
    }
}

export const isUsernameAvailableAPI = async (username) => {
    try {
        const response = await api.get(`/register/validate/${username}`);
        return response.status === 200;
    } catch (error) {
        console.log('Error validating username');
        console.error(error.message);
    }
}