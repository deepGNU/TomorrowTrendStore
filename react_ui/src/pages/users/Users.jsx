import './Users.css'
import React from 'react'
import { getUsersAPI } from '../../api/resources/users'
import { getUsersBySearchAPI } from '../../api/resources/users'
import { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import User from '../../components/user/User'
import { useNavigate } from 'react-router-dom'
import SearchBar from '../../components/search-bar/SearchBar'
import FilterUsers from '../../components/filter-users/FilterUsers'
import BtnNeon from '../../components/buttons/BtnNeon'

const Users = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const users = useSelector(state => state.users.users)

    const handleAddUserClick = () => {
        navigate('/user-form')
    }

    const handleSearchSubmit = (searchTerm) => {
        getUsersBySearchAPI(dispatch, searchTerm)
    }

    useEffect(() => {
        getUsersAPI(dispatch)
    }, [dispatch])

    return (
        <>
            <div className="top-section">
                <SearchBar onSubmit={handleSearchSubmit} />
                <FilterUsers />
                <h1>Manage Users</h1>
                <BtnNeon text={'Add User'} onClick={handleAddUserClick} />
            </div>
            <div className='users-div'>
                {users.map(user => (
                    <User key={user.id} user={user} />
                ))}
            </div>
        </>
    )
}

export default Users