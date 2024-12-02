#!/bin/bash

set -e

while [[ $# -gt 0 ]]; do
    case "$1" in
        --)
            shift
            break
            ;;
        *)
            shift
            ;;
    esac
done

if [[ $# -lt 2 ]]; then
    echo "Usage: $0 host:port [-- command args]"
    exit 1
fi

hostport=$1
shift

IFS=':' read -r host port <<< "$hostport"

wait_for() {
    local max_attempts=30
    local sleep_interval=1
    local attempt=1

    while [[ $attempt -le $max_attempts ]]; do
        if (echo > "/dev/tcp/$host/$port") &>/dev/null; then
            break
        fi

        echo "Attempt $attempt: Waiting for $host:$port..."
        sleep $sleep_interval
        ((attempt++))
    done

    if [ "$attempt" -gt "$max_attempts" ]; then
        echo "Timeout: Couldn't connect to $host:$port after $((max_attempts * sleep_interval)) seconds"
        exit 1
    fi
}

wait_for

exec "$@"
