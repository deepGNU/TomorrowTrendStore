import './Login.css'
import React from 'react'
import { login } from '../../api/resources/login'
import { useState, useEffect, useRef } from 'react'
import { useDispatch } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import { getLoggedInUserAPI } from '../../api/resources/users'

const Login = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const usernameRef = useRef()
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    const handleSubmit = async (e) => {
        e.preventDefault()
        const loginSucceeded = await login(dispatch, username, password)
        setUsername('')
        setPassword('')
        e.target.reset()
        if (loginSucceeded) {
            getLoggedInUserAPI(dispatch)
            navigate('/')
        }
    }

    const handleUsernameChange = (e) => {
        setUsername(e.target.value)
    }

    const handlePasswordChange = (e) => {
        setPassword(e.target.value)
    }

    useEffect(() => {
        usernameRef.current.focus()
    }, [])

    return (
        <form
            className="login-form"
            onSubmit={handleSubmit}
        >
            <label htmlFor="username">Username</label>
            <input
                ref={usernameRef}
                onChange={handleUsernameChange}
                type="text"
                id="username"
                name="username"
                required
            />

            <label htmlFor="password">Password</label>
            <input
                onChange={handlePasswordChange}
                type="password"
                id="password"
                name="password"
                required
            />

            <button
                className='neon-sign'
                type="submit"
                title='Login'
            >
                Login
            </button>

            <hr />
            <div>New user? =&gt;&nbsp;
                <button
                    className='neon-sign'
                    onClick={() => navigate('/account/register')}
                    title='Register'
                >
                    REGISTER
                </button>
            </div>
        </form>
    )
}

export default Login