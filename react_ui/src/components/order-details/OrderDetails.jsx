import './OrderDetails.css'
import React from 'react'
import { useParams } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { getOrderByIdAPI } from '../../api/resources/orders'
import OrderLine from '../orderline/OrderLine'

const OrderDetails = () => {
  const { orderId } = useParams()
  const [order, setOrder] = useState()

  useEffect(() => {
    getOrderByIdAPI(orderId)
      .then(order => setOrder(order))
  }, [orderId])

  return (
    <div className='order-details-div'>
      <h1>Order</h1>
      <p>Order ID: {orderId}</p>
      <p>Order Date: {order?.orderDate}</p>
      <p>Order Status: {order?.status}</p>
      <h2>Order Items</h2>
      {order && order.orderLines.map(orderLine => (
        <OrderLine key={orderLine.id} orderLine={orderLine} />
      ))}
    </div>
  )
}

export default OrderDetails