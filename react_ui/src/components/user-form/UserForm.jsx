import './UserForm.css'
import React from 'react'
import useUserForm from '../../hooks/useUserForm'
import FileInput from '../file-input/FileInput'
import BtnNeon from '../buttons/BtnNeon'
import { COUNTRY_CODES } from '../../utils/country-codes'
import { USER_TYPE_IDS } from '../../utils/user-types'
import { Blocks } from 'react-loader-spinner'
import { useSelector } from 'react-redux'

const UserForm = () => {
    const { isInEditMode, type, username, usernameInputRef, firstName, lastName, email, phoneNumber, profileImageURL, addressLine, city, country, postalCode, password, confirmPassword, passwordInputRef, passwordsMatch, imageInputRef, imageFileToUpload, imageFileToUploadURL, imageIsUploading, handleTypeChange, handleUsernameChange, handleFirstNameChange, handleLastNameChange, handleEmailChange, handlePhoneNumberChange, handleAddressLineChange, handleCityChange, handleCountryChange, handlePostalCodeChange, handleImageChange, handleImageClear, handlePasswordChange, handleConfirmPasswordChange, handleEditSubmit, handleCreateSubmit } = useUserForm()
    const userRole = useSelector(state => state.currentUser.role)
    return (
        <div className='user-form-wrapper'>
            {isInEditMode ? <h1>Edit User '{username}'</h1> : <h1>Create User</h1>}

            {imageIsUploading &&
                <div className='loader'>
                    <h1>Uploading image...</h1>
                    <Blocks
                        width={200}
                        height={200}
                    />
                </div>}

            <form onSubmit={isInEditMode ? handleEditSubmit : handleCreateSubmit} className='user-form'>
                <FileInput
                    inputRef={imageInputRef}
                    onChange={handleImageChange}
                    onClear={handleImageClear}
                    isFileToUpload={imageFileToUpload ? true : false}
                    imageURL={imageFileToUploadURL ?? profileImageURL}
                />

                <div className='right-section'>


                    {USER_TYPE_IDS[userRole] === 999 && (
                        <div className='user-form-field'>
                            <label htmlFor="type">Type</label>
                            <select onChange={handleTypeChange} name="type" id="type" value={type ?? 0}>
                                {Object.entries(USER_TYPE_IDS).map(([key, value]) => (
                                    <option key={key} value={value}>{key}</option>
                                ))}
                            </select>
                        </div>
                    )}

                    <div className='user-form-field'>
                        <label htmlFor="username">Username</label>
                        <input
                            onChange={handleUsernameChange}
                            value={username ?? ''}
                            ref={usernameInputRef}
                            required
                            type="text"
                            name="username"
                            id="username"
                            maxLength={50}
                        />
                    </div>

                    {!isInEditMode &&
                        <div className='user-form-field'>
                            <label htmlFor="password">Password</label>
                            <input onChange={handlePasswordChange} ref={passwordInputRef} type="password" name="password" id="password" value={password ?? ''} required maxLength={128} />
                        </div>}

                    {!isInEditMode &&
                        <div className='user-form-field'>
                            <label htmlFor="confirmPassword">Confirm Password</label>
                            <input onChange={handleConfirmPasswordChange} className={passwordsMatch ? '' : 'password-mismatch'} type="password" name="confirmPassword" id="confirmPassword" value={confirmPassword ?? ''} required maxLength={128} />
                        </div>}

                    <div className='user-form-field'>
                        <label htmlFor="firstName">First Name</label>
                        <input onChange={handleFirstNameChange} type="text" name="firstName" id="firstName" value={firstName ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="lastName">Last Name</label>
                        <input onChange={handleLastNameChange} type="text" name="lastName" id="lastName" value={lastName ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="email">Email</label>
                        <input onChange={handleEmailChange} type="email" name="email" id="email" value={email ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="phoneNumber">Phone Number</label>
                        <input onChange={handlePhoneNumberChange} type="tel" name="phoneNumber" id="phoneNumber" value={phoneNumber ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="addressLine">Address Line</label>
                        <input onChange={handleAddressLineChange} type="text" name="addressLine" id="addressLine" value={addressLine ?? ''} required maxLength={100} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="city">City</label>
                        <input onChange={handleCityChange} type="text" name="city" id="city" value={city ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="postalCode">Postal Code</label>
                        <input onChange={handlePostalCodeChange} type="text" name="postalCode" id="postalCode" value={postalCode ?? ''} required maxLength={50} />
                    </div>

                    <div className='user-form-field'>
                        <label htmlFor="country">Country</label>
                        <select onChange={handleCountryChange} name="country" id="country" value={country ?? ''} required>
                            <option value=''>Select a country</option>
                            {Object.entries(COUNTRY_CODES).map(([key, value]) => (
                                <option key={key} value={value}>{key}</option>
                            ))}
                        </select>
                    </div>
                </div>

                <div className='bottom-section'>
                    <BtnNeon text={'Submit'} className='submit-btn' />
                </div>
            </form>
        </div>
    )
}

export default UserForm