import React from 'react'
import { Navigate } from 'react-router-dom'
import { useSelector } from 'react-redux'

const PrivateRoute = ({ element }) => {
    const isAuthorized = useSelector(state => state.currentUser.isAuthorizedForControlPanel)
    
    if (!isAuthorized)
        return <Navigate to='/unauthorized' />

    return element
}

export default PrivateRoute