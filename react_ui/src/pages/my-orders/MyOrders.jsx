import './MyOrders.css'
import React from 'react'
import { useSelector } from 'react-redux'
import { useState, useEffect } from 'react'
import { getOrdersByUserIdAPI } from '../../api/resources/orders'
import Orders from '../../components/orders/Orders'

const MyOrders = () => {
  const [myOrders, setMyOrders] = useState([])
  const myId = useSelector(state => state.currentUser.id)

  useEffect(() => {
    getOrdersByUserIdAPI(myId)
      .then(orders => setMyOrders(orders))
  }, [myId])

  return (
    <div>
      <h1>My Orders</h1>
      <Orders orders={myOrders} />
    </div>
  )
}

export default MyOrders