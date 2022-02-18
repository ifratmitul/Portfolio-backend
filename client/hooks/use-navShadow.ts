import { useCallback, useEffect, useState } from "react";
const useNavShadow = (): boolean => {
  const [shadow, setShadow] = useState(true);
  const handleScroll = useCallback(() => {
    if (window.scrollY < 76) {
      setShadow(false);
    } else if (window.scrollY > 36) {
      setShadow(true);
    }
  }, [setShadow]);

  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, [handleScroll]);

  return shadow;
};

export default useNavShadow;
