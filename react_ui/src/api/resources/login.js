import api from "../e-store-api";
import { setAuthTokenFromSessionStorage } from "../e-store-api";
import { resetState } from "../../features/shared-actions";
import jwtDecoder from "../../utils/jwt-decoder";
import { setCurrentUser } from "../../features/current-user/current-user-slice";
import Swal from "sweetalert2";

const wrongCredentialsMessage = "Invalid username or password. Please try again.";

export const login = async (dispatch, username, password) => {
    let res = null;
    try {
        res = await api.post("/Login", { username, password });
        const token = res.data;
        const decodedToken = jwtDecoder(token);

        dispatch(setCurrentUser({ jwt: token, id: decodedToken.sub, role: decodedToken.role }));

        Swal.fire({
            icon: 'success',
            title: 'Login Success',
            text: `Welcome to E-Store, ${username}`,
            timer: 2000,
            showConfirmButton: false,
        })

        return setAuthTokenFromSessionStorage();
    } catch (error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error.response.status === 401 ? wrongCredentialsMessage : error.message,
            timer: 5000,
        })
        console.error(error.message);
    }
}

export const logout = async (dispatch) => {
    try {
        await dispatch(resetState());
        setAuthTokenFromSessionStorage();
        Swal.fire({
            icon: 'success',
            title: 'Logout Success',
            text: `See you again!`,
            timer: 2000,
            showConfirmButton: false,
        })

    } catch (error) {
        console.error(error.message);
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error.message,
            timer: 5000,
        })        
    }
}