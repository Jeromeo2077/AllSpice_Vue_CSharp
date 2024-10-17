import Pop from '../utils/Pop.js'
import { SocketHandler } from '../utils/SocketHandler.js'

class SocketService extends SocketHandler {
  constructor() {
    super()
    this
      .on('error', this.onError)
  }

  onError(e) {
    Pop.toast(e.message, 'error')
  }
}

export const socketService = new SocketService()
