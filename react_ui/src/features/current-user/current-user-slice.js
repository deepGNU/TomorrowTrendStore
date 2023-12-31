import { createSlice } from "@reduxjs/toolkit";
import { resetState } from "../shared-actions";

const rolesAuthorizedForPrivateRoutes = ["Admin", "Worker"];

const getIsAuthorizedForControlPanel = () => {
    const role = sessionStorage.getItem('user-role') ?? null;
    return rolesAuthorizedForPrivateRoutes.includes(role);
}

const initialState = {
    jwt: sessionStorage.getItem('e-store-jwt') ?? null,
    id: sessionStorage.getItem('user-id') ?? null,
    role: sessionStorage.getItem('user-role') ?? null,
    isLoggedIn: sessionStorage.getItem('e-store-jwt') ? true : false,
    isAuthorizedForControlPanel: getIsAuthorizedForControlPanel(),
};

const notLoggedInState = {
    jwt: null,
    id: null,
    role: null,
    isLoggedIn: false,
    isAuthorizedForControlPanel: false,
};

const currentUserSlice = createSlice({
    name: "currentUser",
    initialState,
    reducers: {
        setCurrentUser(state, action) {
            const { jwt, id, role } = action.payload;
            state.jwt = jwt;
            state.id = id;
            state.role = role;
            sessionStorage.setItem("e-store-jwt", jwt);
            sessionStorage.setItem("user-id", id);
            sessionStorage.setItem("user-role", role);
            state.isLoggedIn = true;
            state.isAuthorizedForControlPanel = getIsAuthorizedForControlPanel();
        },
    },
    extraReducers: (builder) => {
        builder.addCase(resetState, () => {
            sessionStorage.removeItem("e-store-jwt");
            sessionStorage.removeItem("user-id");
            sessionStorage.removeItem("user-role");
            return notLoggedInState;
        });
    }
});

export const { setCurrentUser } = currentUserSlice.actions;

export default currentUserSlice.reducer;