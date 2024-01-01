import './App.css';
import { Route, Routes } from 'react-router-dom';
import Cart from './pages/cart/Cart';
import Nav from './components/nav/Nav';
import Login from './pages/login/Login';
import Users from './pages/users/Users';
import OrdersPage from './pages/orders-page/OrdersPage';
import Products from './pages/products/Products';
import Home from './pages/home/Home';
import Register from './components/register/Register';
import UserForm from './components/user-form/UserForm';
import OrderForm from './components/order-form/OrderForm';
import EditProducts from './pages/edit-products/EditProducts';
import ProductForm from './components/product-form/ProductForm';
import UserDetails from './components/user-details/UserDetails';
import PrivateRoute from './components/private-route/PrivateRoute';
import OrderDetails from './components/order-details/OrderDetails';
import ProductDetails from './components/product-details/ProductDetails';
import MyOrders from './pages/my-orders/MyOrders';
import MyProfile from './pages/my-profile/MyProfile';
import About from './pages/about/About';
import Footer from './components/footer/Footer';

import { fetchCart } from './api/resources/carts';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import useAutoLogout from './hooks/useAutoLogout';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  const isLoggedIn = useSelector((state) => state.currentUser.isLoggedIn);
  useAutoLogout();

  const dispatch = useDispatch();

  useEffect(() => {
    if (isLoggedIn) fetchCart(dispatch);
  }, [dispatch, isLoggedIn]);

  return (
    <div className="App">
      <Nav />
      <ToastContainer />
      <Routes>
        <Route path='/account/register' element={<Register />} />
        <Route path='/account/login' element={<Login />} />
        <Route path="/" element={<Home />} />
        <Route path="/products" element={<Products />} />
        <Route path='/cart' element={<Cart />} />
        <Route path='/about' element={<About />} />
        <Route path='/contact' element={<h1>Contact</h1>} />
        <Route path='/my-orders' element={isLoggedIn ? <MyOrders /> : <Login />} />
        <Route path='/my-profile' element={isLoggedIn ? <MyProfile /> : <Login />} />
        <Route path='/products/:productId' element={<ProductDetails />} />
        <Route path='/unauthorized' element={<h1>Unauthorized</h1>} />
        <Route path="/user-form" element={<UserForm />} />
        <Route path='/orders/:orderId' element={<OrderDetails />} />

        {/* Private routes – for authorized admins & employees only. */}
        <Route path='/edit-products' element={<PrivateRoute element={<EditProducts />} />} />
        <Route path='/users/:userId' element={<PrivateRoute element={<UserDetails />} />} />
        <Route path='/orders' element={<PrivateRoute element={<OrdersPage />} />} />
        <Route path="/users" element={<PrivateRoute element={<Users />} />} />
        <Route path='product-form' element={<PrivateRoute element={<ProductForm />} />} />
        <Route path='/order-form/:orderId' element={<PrivateRoute element={<OrderForm />} />} />
        <Route path='/order-form' element={<PrivateRoute element={<OrderForm />} />} />
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
