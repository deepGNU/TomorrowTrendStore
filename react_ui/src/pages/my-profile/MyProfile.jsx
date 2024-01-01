import './MyProfile.css'
import React from 'react'
import { getLoggedInUserAPI } from '../../api/resources/users'
import { useState, useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { setUserToEdit } from '../../features/users/users-slice'
import BtnNeon from '../../components/buttons/BtnNeon'
import { useNavigate } from 'react-router-dom'
import { COUNTRY_NAMES } from '../../utils/country-codes'

const MyProfile = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [myUser, setMyUser] = useState({})
    const myId = useSelector(state => state.currentUser.id)

    const handleEditClick = () => {
        dispatch(setUserToEdit(myUser))
        navigate('/user-form')
    }

    useEffect(() => {
        const fetchMyUser = async () => {
            const user = await getLoggedInUserAPI(myId)
            setMyUser(user)
        }
        fetchMyUser()
    }, [myId])

    return (

        <div className='my-profile-wrapper'>
            <h1>{myUser?.username}</h1>

            <div className="user-details-div">
                <img
                    className='my-profile-image' src={myUser?.profileImageURL ?? 'https://media.istockphoto.com/id/1337144146/vector/default-avatar-profile-icon-vector.jpg?s=612x612&w=0&k=20&c=BIbFwuv7FxTWvh5S3vB6bkT0Qv8Vn8N5Ffseq84ClGI='}
                    alt="Profile"
                />

                <BtnNeon text={'Edit Profile'} onClick={handleEditClick} />

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
                            <td>{myUser?.email}</td>
                            <td>{myUser?.firstName}</td>
                            <td>{myUser?.lastName}</td>
                            <td>{myUser?.phoneNumber}</td>
                            <td>{myUser?.type}</td>
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
                            <td>{myUser?.address?.addressLine}</td>
                            <td>{myUser?.address?.city}</td>
                            <td>{myUser?.address?.postalCode}</td>
                            <td>{COUNTRY_NAMES[myUser?.address?.country]}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default MyProfile