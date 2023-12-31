import './Orders.css'
import React from 'react'
import Order from '../../components/order/Order';

const Orders = ({ orders }) => {
    return (
        <div className='orders-div'>
            {orders.map((order, index) => (
                <Order key={index} order={order} />
            ))}
        </div>
    )
}

export default Orders