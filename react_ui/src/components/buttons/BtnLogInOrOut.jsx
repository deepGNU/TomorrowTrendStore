import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useNavigate, useLocation } from 'react-router-dom'
import { logout } from '../../api/resources/login'


const BtnLogInOrOut = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const location = useLocation()
    const pathIsLoginForm = location.pathname === '/account/login'
    const isLoggedIn = useSelector(state => state.currentUser.isLoggedIn);

    const navigateToLogin = () => {
        navigate('/account/login')
    }

    const handleLogout = () => {
        logout(dispatch)
        navigate('/')
    }

    if (pathIsLoginForm) {
        return null
    }

    return (
        <div className='login-logout-container'>
            {isLoggedIn ? (
                <button
                    className='login-logout-btn neon-sign'
                    onClick={handleLogout}
                    title='Logout'
                >
                    Logout
                </button>
            ) : (
                <button
                    className='login-logout-btn neon-sign'
                    onClick={navigateToLogin}
                    title='Login'
                >
                    Login
                </button>
            )}
        </div>
    )
}

export default BtnLogInOrOut