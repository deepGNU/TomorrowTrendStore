import './User.css'
import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { setUserToEdit } from '../../features/users/users-slice'
import { useNavigate } from 'react-router-dom'
import { deleteUserAPI } from '../../api/resources/users'
import BtnNeon from '../buttons/BtnNeon'
import { COUNTRY_NAMES } from '../../utils/country-codes'

const User = ({ user }) => {
    const isAdmin = useSelector(state => state.currentUser.role === 'Admin')
    const dispatch = useDispatch()
    const navigate = useNavigate()

    const typeDictionary = {
        999: 'admin',
        1: 'worker',
        0: 'customer',
    }

    const handleEdit = (e) => {
        e.stopPropagation()
        dispatch(setUserToEdit(user))
        navigate('/user-form')
    }

    const handleViewDetails = () => {
        navigate(`/users/${user.id}`)
    }

    const handleDelete = (e) => {
        e.stopPropagation()
        const confirmDelete = window.confirm(`Are you sure you want to delete ${user.username}?`)
        if (confirmDelete) deleteUserAPI(dispatch, user.id)
    }

    return (
        <div
            className={`user-card ${typeDictionary[user.type]}`}
            onClick={handleViewDetails}
        >
            <div className='user-left-section'>
                <h3>{user.username}</h3>
                <img className='user-image' src={user.profileImageURL ?? 'https://media.istockphoto.com/id/1337144146/vector/default-avatar-profile-icon-vector.jpg?s=612x612&w=0&k=20&c=BIbFwuv7FxTWvh5S3vB6bkT0Qv8Vn8N5Ffseq84ClGI='} alt="Profile" />
            </div>

            <table className='user-details-table'>
                <thead>
                    <tr>
                        <th>Email</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Phone Number</th>
                        <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{user?.email}</td>
                        <td>{user?.firstName}</td>
                        <td>{user?.lastName}</td>
                        <td>{user?.phoneNumber}</td>
                        <td>{user?.type}</td>
                    </tr>
                </tbody>
            </table>

            <table className='user-details-table'>
                <thead>
                    <tr>
                        <th>Address Line</th>
                        <th>City</th>
                        <th>Postal Code</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{user?.address?.addressLine}</td>
                        <td>{user?.address?.city}</td>
                        <td>{user?.address?.postalCode}</td>
                        <td>{COUNTRY_NAMES[user?.address?.country]}</td>
                    </tr>
                </tbody>
            </table>

            {isAdmin &&
                <div className='user-btns-div'>
                    <BtnNeon text={'Edit'} onClick={handleEdit} />
                    <BtnNeon text={'Delete'} onClick={handleDelete} />
                </div>}
        </div>
    )
}

export default User