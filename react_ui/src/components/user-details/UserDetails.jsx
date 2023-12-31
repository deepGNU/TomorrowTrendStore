import './UserDetails.css'
import React from 'react'
import { useParams } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { getUserByIdAPI } from '../../api/resources/users'
import Orders from '../orders/Orders'
import { COUNTRY_NAMES } from '../../utils/country-codes'

const UserDetails = () => {
    const { userId } = useParams()
    const [user, setUser] = useState()

    useEffect(() => {
        getUserByIdAPI(userId)
            .then(user => setUser(user))
    }, [userId])

    return (
        <div className='user-profile-div'>
            <h1>{user?.username}</h1>

            <div className='user-details-div'>
                <img src={user?.profileImageURL} alt={user?.username} />

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
            </div>

            <hr />
            <h2>{user?.username}'s Orders</h2>
            {user && <Orders orders={user.orders} />}
        </div>
    )
}

export default UserDetails