import './OrderForm.css'
import React from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { useState } from 'react'
import { updateOrderAPI } from '../../api/resources/orders'
import { createOrderAPI } from '../../api/resources/orders'
import { useDispatch } from 'react-redux'
import BtnNeon from '../buttons/BtnNeon'
import ORDER_STATUSES from '../../utils/order-statuses'

const OrderForm = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const { orderId } = useParams()
    const order = useSelector(state => state.orders.orders)
        .find(order => order.id === parseInt(orderId))
    const [status, setStatus] = useState(order?.status)
    const [totalPrice, setTotalPrice] = useState(order?.totalPrice)
    const [userId, setUserId] = useState(order?.userId)

    const handleStatusChange = (e) => {
        setStatus(e.target.value)
    }

    const handleTotalPriceChange = (e) => {
        setTotalPrice(e.target.value)
    }

    const handleUserIdChange = (e) => {
        setUserId(e.target.value)
    }

    const handleSubmit = async (e) => {
        e.preventDefault()
        if (orderId) {
            await updateOrderAPI(dispatch, orderId, { ...order, status, totalPrice })
        } else {
            await createOrderAPI(dispatch, { status, totalPrice, userId })
        }
        setStatus('')
        setTotalPrice('')
        navigate(-1)
    }

    return (
        <div>
            <h1>OrderForm</h1>
            <form
                className='order-form'
                onSubmit={handleSubmit}
            >
                <input
                    onChange={handleUserIdChange}
                    type="text"
                    value={userId}
                    placeholder='User ID'
                />

                <select
                    onChange={handleStatusChange}
                    value={status}
                >
                    {ORDER_STATUSES.map(status => (
                        <option
                            key={status}
                            value={status}
                        >
                            {status}
                        </option>
                    ))}
                </select>

                <input
                    onChange={handleTotalPriceChange}
                    type="text"
                    value={totalPrice}
                    placeholder='Total Price'
                />
                <BtnNeon text={'Submit'} />
            </form>
        </div>
    )
}

export default OrderForm