import { useDispatch, useSelector } from 'react-redux'
import { logout } from '../api/resources/login'
import jwtDecoder from '../utils/jwt-decoder'
import { useEffect } from 'react'

const useAutoLogout = () => {
    const dispatch = useDispatch()
    const jwt = useSelector(state => state.currentUser.jwt)
    const expirationTime = jwtDecoder(jwt)?.exp
    const remainingMilliseconds = expirationTime * 1000 - Date.now()

    useEffect(() => {
        if (!expirationTime) {
            return
        }

        const logoutTimer = setTimeout(() => {
            logout(dispatch)
            alert("Your session has expired. Please log in again.")
        }, remainingMilliseconds)

        return () => {
            clearTimeout(logoutTimer)
        }
    }, [jwt, expirationTime, remainingMilliseconds, dispatch])
}

export default useAutoLogout