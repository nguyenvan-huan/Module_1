#!/usr/bin/env bash
set -euo pipefail

PACKAGE_NAME="DeviceControlServer"
PACKAGE_PATH=".github/package"   # bỏ dấu " thừa

rm -rf "${PACKAGE_PATH}"
mkdir -p "${PACKAGE_PATH}/${PACKAGE_NAME}"

cp -r bin/Release/net8.0/linux-x64/publish/Test "${PACKAGE_PATH}/${PACKAGE_NAME}/"

cd "${PACKAGE_PATH}"

zip -r "${PACKAGE_NAME}.zip" "${PACKAGE_NAME}"
