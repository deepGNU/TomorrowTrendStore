import './Order.css'
import React from 'react'
import { useNavigate } from 'react-router-dom'
import { deleteOrderAPI } from '../../api/resources/orders'
import { useDispatch } from 'react-redux'
import BtnNeon from '../buttons/BtnNeon'

const Order = ({ order }) => {
    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleViewDetails = () => {
        navigate(`/orders/${order.id}`)
    }

    const handleDelete = (e) => {
        e.stopPropagation()
        const confirmDelete = window.confirm(`Are you sure you want to delete order #${order.id}?`)
        if (!confirmDelete) return
        deleteOrderAPI(dispatch, order.id)
    }

    const handleEditClick = (e) => {
        e.stopPropagation()
        navigate(`/order-form/${order.id}`)
    }

    return (
        <div
            className='order-card neon-sign'
            onClick={handleViewDetails}
        >
            <h3>Order ID: {order?.id}</h3>
            <p>Order Date: {order?.orderDate}</p>
            <p>Order Status: {order?.status}</p>

            <BtnNeon text={'Delete'} onClick={handleDelete} />
            <BtnNeon text={'Edit'} onClick={handleEditClick} />
        </div>
    )
}

export default Order