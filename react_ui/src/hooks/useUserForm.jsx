import { useState, useEffect, useRef } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import useImageUpload from './useImageUpload'
import { editUser } from '../api/resources/users'
import { useNavigate, useLocation } from 'react-router-dom'
import { setUserToEdit } from '../features/users/users-slice'
import { registerAPI } from '../api/resources/register'
import { isUsernameAvailableAPI } from '../api/resources/register'
import { login } from '../api/resources/login'
import Swal from 'sweetalert2'
import { toast } from 'react-toastify'

const useUserForm = () => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const path = useLocation().pathname
    const isRegisterPage = path.includes('/register')
    const usernameInputRef = useRef()
    const passwordInputRef = useRef()
    const { imageInputRef, imageFileToUpload, imageFileToUploadURL, handleImageChange, handleImageClear, handleImageUpload, imageIsUploading } = useImageUpload()
    const userToEdit = useSelector(state => state.users.userToEdit)
    const [type, setType] = useState(userToEdit?.type ?? 0)
    const [username, setUsername] = useState(userToEdit?.username)
    const [firstName, setFirstName] = useState(userToEdit?.firstName)
    const [lastName, setLastName] = useState(userToEdit?.lastName)
    const [email, setEmail] = useState(userToEdit?.email)
    const [phoneNumber, setPhoneNumber] = useState(userToEdit?.phoneNumber)
    const [profileImageURL, setProfileImageURL] = useState(userToEdit?.profileImageURL)
    const [addressLine, setAddressLine] = useState(userToEdit?.address?.addressLine)
    const [city, setCity] = useState(userToEdit?.address?.city)
    const [postalCode, setPostalCode] = useState(userToEdit?.address?.postalCode)
    const [country, setCountry] = useState(userToEdit?.address?.country)
    const [password, setPassword] = useState()
    const [confirmPassword, setConfirmPassword] = useState()
    const passwordsMatch = password === confirmPassword;

    useEffect(() => {
        console.log(imageIsUploading)
    }, [imageIsUploading])

    useEffect(() => {
        setType(userToEdit?.type)
        setUsername(userToEdit?.username)
        setFirstName(userToEdit?.firstName)
        setLastName(userToEdit?.lastName)
        setEmail(userToEdit?.email)
        setPhoneNumber(userToEdit?.phoneNumber)
        setProfileImageURL(userToEdit?.profileImageURL)
        setAddressLine(userToEdit?.address?.addressLine)
        setCity(userToEdit?.address?.city)
        setPostalCode(userToEdit?.address?.postalCode)
        setCountry(userToEdit?.address?.country)
    }, [userToEdit])

    const handleTypeChange = (event) => {
        setType(event.target.value)
    }

    const handleUsernameChange = (event) => {
        setUsername(event.target.value)
    }

    const handleFirstNameChange = (event) => {
        setFirstName(event.target.value)
    }

    const handleLastNameChange = (event) => {
        setLastName(event.target.value)
    }

    const handleEmailChange = (event) => {
        setEmail(event.target.value)
    }

    const handlePhoneNumberChange = (event) => {
        setPhoneNumber(event.target.value)
    }

    const handleAddressLineChange = (event) => {
        setAddressLine(event.target.value)
    }

    const handleCityChange = (event) => {
        setCity(event.target.value)
    }

    const handleCountryChange = (event) => {
        setCountry(event.target.value)
    }

    const handlePostalCodeChange = (event) => {
        setPostalCode(event.target.value)
    }

    const handlePasswordChange = (event) => {
        setPassword(event.target.value)
    }

    const handleConfirmPasswordChange = (event) => {
        setConfirmPassword(event.target.value)
    }

    const getUpatedUser = () => {
        return {
            id: userToEdit?.id ?? 0,
            type,
            username,
            firstName,
            lastName,
            email,
            phoneNumber,
            profileImageURL,
            passwordHash: password ? password : userToEdit?.passwordHash,
            address: userToEdit?.address ? userToEdit.address : {
                addressLine,
                city,
                country: parseInt(country),
                postalCode
            }
        }
    }

    const handleCreateSubmit = async (event) => {
        event.preventDefault()

        if (!/^[\d\s()+-]+$/.test(phoneNumber)) {
            alert('Please enter a valid phone number.')
            setPhoneNumber('')
            return

        }

        if (!passwordsMatch) {
            toast.error('Passwords do not match!')
            setPassword('')
            setConfirmPassword('')
            passwordInputRef.current.focus()
            return
        }

        const userNameIsAvailable = await isUsernameAvailableAPI(username)

        if (!userNameIsAvailable) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: `Username '${username}' is already taken. Please choose another username.`,
            })
            setUsername('')
            usernameInputRef.current.focus()
            return
        }

        if (!imageFileToUpload) {
            registerUser(getUpatedUser())
            return
        }

        const uploadedImageURL = await handleImageUpload()

        if (!uploadedImageURL) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'There was an error uploading the image. Do you want to continue without uploading the image?',
                showCancelButton: true,
                confirmButtonText: 'Continue Anyway',
            }).then((result) => {
                if (!result.isConfirmed) return
                registerUser(getUpatedUser())
            })
            return
        }

        registerUser({ ...getUpatedUser(), profileImageURL: uploadedImageURL })
    }

    const registerUser = async (user) => {
        await registerAPI(dispatch, user)

        if (!isRegisterPage) {
            navigate(-1)
            return
        }

        navigate('/')

        const signIn = window.confirm('Registration successful. Do you want to sign in?')

        if (signIn) {
            await login(dispatch, username, password)
            return
        }
    }

    const handleEditSubmit = async (event) => {
        event.preventDefault()

        if (!imageFileToUpload) {
            await editUser(dispatch, getUpatedUser())
            navigate('/users')
            dispatch(setUserToEdit(null))
            return
        }

        const uploadedImageURL = await handleImageUpload()

        if (!uploadedImageURL) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'There was an error uploading the image. Do you want to continue without uploading the image?',
                showCancelButton: true,
                confirmButtonText: 'Continue Anyway',
            }).then((result) => {
                if (!result.isConfirmed) return
                editUser(dispatch, getUpatedUser())
                navigate('/users')
            })
            return
        }

        await editUser(dispatch, { ...getUpatedUser(), profileImageURL: uploadedImageURL })
        navigate('/users')
    }

    return {
        isInEditMode: !!userToEdit,
        type,
        username,
        usernameInputRef,
        firstName,
        lastName,
        email,
        phoneNumber,
        profileImageURL,
        addressLine,
        city,
        postalCode,
        country,
        password,
        confirmPassword,
        passwordInputRef,
        passwordsMatch,
        imageInputRef,
        imageFileToUpload,
        imageFileToUploadURL,
        handleTypeChange,
        handleUsernameChange,
        handleFirstNameChange,
        handleLastNameChange,
        handleEmailChange,
        handlePhoneNumberChange,
        handleAddressLineChange,
        handleCityChange,
        handlePostalCodeChange,
        handleCountryChange,
        handleImageChange,
        handleImageClear,
        imageIsUploading,
        handlePasswordChange,
        handleConfirmPasswordChange,
        getUpatedUser,
        handleEditSubmit,
        handleCreateSubmit
    }
}

export default useUserForm