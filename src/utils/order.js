import uniqueId from 'lodash/uniqueId'
// import { ORDER_STATUS, ORDER_TYPES } from '@/constants'
//
// const getOrderDefaults = () => ({
//   status: ORDER_STATUS.INIT,
//   type: ORDER_TYPES.RESTAURANT,
//   user: '8124',
//   table: 4,
//   number: 1,
//   items: [],
//   id: uniqueId(),
//   timestamp: Date.now()
// })
//
// // eslint-disable-next-line
// export const buildOrder = order => ({
//   ...getOrderDefaults(),
//   ...order
// })

const getMenuItemDefaults = () => ({
  id: uniqueId()
})

export const buildMenuItem = item => ({
  ...getMenuItemDefaults(),
  ...item
})
